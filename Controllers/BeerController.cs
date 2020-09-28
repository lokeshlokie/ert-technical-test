﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ert_beer_app.Interfaces;
using ert_beer_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppContext = ert_beer_app.Models.AppContext;

namespace ert_beer_app.Controllers
{
    [Route("api/beer")]
    [ApiController]
    public class BeerController : Controller
    {
        private AppContext Context { get; }
        private IBeerService BeerService { get; }
        private ILogger<BeerController> Logger { get; }

        public BeerController(AppContext appContext, IBeerService beerService, ILogger<BeerController> logger)
        {
            Context = appContext;
            BeerService = beerService;
            Logger = logger;
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] GetBeersRequest request)
        {
            try
            {
                IQueryable<Beer> query = Context.Beers;
                if (string.IsNullOrEmpty(request.BeerName) == false)
                {
                    query = query.Where(x => x.Name.Contains(request.BeerName));
                }

                query = query.OrderBy(x => x.Id)
                    .Skip((request.Page - 1) * request.PerPage)
                    .Take(request.PerPage);
                var beersFromDb = query.ToList();
                var beersFromService = await BeerService.GetBeersAsync(request);
                bool isEqual = beersFromService.All(beerFromService => beersFromDb.Any(beerFromDb => beerFromService.Id == beerFromDb.Id));
                if (isEqual == false)
                {
                    var itemsThatOnlyInService = await GetDifferenceAsync(beersFromDb, beersFromService);
                    // to prevent duplicate id exceptions
                    await CacheItemsNotInDbAsync(itemsThatOnlyInService);
                    var itemsThatOnlyInDb = await GetDifferenceAsync(beersFromService, beersFromDb);
                    if (itemsThatOnlyInDb.Count != 0)
                    {
                        return Json(beersFromService);
                    }
                    else
                    {
                        beersFromDb.AddRange(itemsThatOnlyInService);
                    }
                }

                return Json(beersFromDb);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets items that are in the second collection, but not in the first one
        /// </summary>
        /// <param name="firstCollection"></param>
        /// <param name="secondCollection"></param>
        /// <returns></returns>
        private async Task<List<Beer>> GetDifferenceAsync(List<Beer> firstCollection, List<Beer> secondCollection)
        {
            var taskResult = await Task.Run(() =>
            {
                var result = new List<Beer>();
                foreach (var secondCollectionItem in secondCollection)
                {
                    if (firstCollection.Any(firstCollectionItem => firstCollectionItem.Id == secondCollectionItem.Id) == false)
                    {
                        result.Add(secondCollectionItem);
                    }
                }

                return result;
            });

            return taskResult;
        }

        private async Task CacheItemsNotInDbAsync(List<Beer> differenceBetweenDbAndService)
        {
            var itemsNotInDb = await GetItemsNotInDbAsync(differenceBetweenDbAndService);
            await Context.Beers.AddRangeAsync(itemsNotInDb);
            await Context.SaveChangesAsync();
        }

        private async Task<List<Beer>> GetItemsNotInDbAsync(List<Beer> collectionToAdd)
        {
            var taskResult = await Task.Run(() =>
            {
                var newItemIds = collectionToAdd.Select(item => item.Id).Distinct().ToArray();
                var itemsInDb = Context.Beers.Where(item => newItemIds.Contains(item.Id))
                    .Select(item => item.Id).ToArray();
                var usersNotInDb = collectionToAdd.Where(item => itemsInDb.Contains(item.Id) == false);
                return usersNotInDb.ToList();
            });

            return taskResult;
        }
    }
}