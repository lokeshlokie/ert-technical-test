﻿using ert_beer_app.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ert_beer_app.Tests
{
    public class BeerModelMapperTest
    {
        [Test]
        public void TestConvertResonseToBeer()
        {

            var model = "[{'id':55,'name':'Amarillo - IPA Is Dead','tagline':'Single Hop India Pale Ale.','first_brewed':'01 / 2013','description':'Citrus fruit. Lots of citrus fruit. Think blood orange, orange zest and grapefruit, tangerine and lemon; the fruit is balanced by floral notes in the most classic of new wave IPA hops. Amarillo adds a zesty, pithy character that sits beautifully alongside hints of toffee and honeycomb.','image_url':'https://images.punkapi.com/v2/55.png','abv':7.2,'ibu':70,'target_fg':1012,'target_og':1067,'ebc':30,'srm':15,'ph':4.4,'attenuation_level':82.1,'volume':{'value':20,'unit':'litres'},'boil_volume':{'value':25,'unit':'litres'},'method':{'mash_temp':[{'temp':{'value':65,'unit':'celsius'},'duration':null}],'fermentation':{'temp':{'value':19,'unit':'celsius'}},'twist':null},'ingredients':{'malt':[{'name':'Extra Pale','amount':{'value':4.88,'unit':'kilograms'}},{'name':'Caramalt','amount':{'value':0.31,'unit':'kilograms'}},{'name':'Dark Crystal','amount':{'value':0.06,'unit':'kilograms'}}],'hops':[{'name':'Amarillo','amount':{'value':20,'unit':'grams'},'add':'start','attribute':'bitter'},{'name':'Amarillo','amount':{'value':25,'unit':'grams'},'add':'middle','attribute':'flavour'},{'name':'Amarillo','amount':{'value':37.5,'unit':'grams'},'add':'end','attribute':'flavour'},{'name':'Amarillo','amount':{'value':250,'unit':'grams'},'add':'dry hop','attribute':'aroma'}],'yeast':'Wyeast 1056 - American Ale™'},'food_pairing':['Bratwurst sausage with spicy mustard','Fried American bacon with chilli flakes added to the top','Dark chocolate chip cookies'],'brewers_tips':'Use the freshest hops for the most impact. It seems obvious but in a single hop beer, you want the hops to be at their best.','contributed_by':'Sam Mason <samjbmason>'}]";

            var result = BeerModelMapper.ConvertResonseToBeer(model);
            Assert.IsNotNull(result);
            Assert.AreSame(55,result.First().Id);
        }

        [Test]
        public void TestConvertResonseToBeerDetail()
        {

            var model = "[{'id':55,'name':'Amarillo - IPA Is Dead','tagline':'Single Hop India Pale Ale.','first_brewed':'01 / 2013','description':'Citrus fruit. Lots of citrus fruit. Think blood orange, orange zest and grapefruit, tangerine and lemon; the fruit is balanced by floral notes in the most classic of new wave IPA hops. Amarillo adds a zesty, pithy character that sits beautifully alongside hints of toffee and honeycomb.','image_url':'https://images.punkapi.com/v2/55.png','abv':7.2,'ibu':70,'target_fg':1012,'target_og':1067,'ebc':30,'srm':15,'ph':4.4,'attenuation_level':82.1,'volume':{'value':20,'unit':'litres'},'boil_volume':{'value':25,'unit':'litres'},'method':{'mash_temp':[{'temp':{'value':65,'unit':'celsius'},'duration':null}],'fermentation':{'temp':{'value':19,'unit':'celsius'}},'twist':null},'ingredients':{'malt':[{'name':'Extra Pale','amount':{'value':4.88,'unit':'kilograms'}},{'name':'Caramalt','amount':{'value':0.31,'unit':'kilograms'}},{'name':'Dark Crystal','amount':{'value':0.06,'unit':'kilograms'}}],'hops':[{'name':'Amarillo','amount':{'value':20,'unit':'grams'},'add':'start','attribute':'bitter'},{'name':'Amarillo','amount':{'value':25,'unit':'grams'},'add':'middle','attribute':'flavour'},{'name':'Amarillo','amount':{'value':37.5,'unit':'grams'},'add':'end','attribute':'flavour'},{'name':'Amarillo','amount':{'value':250,'unit':'grams'},'add':'dry hop','attribute':'aroma'}],'yeast':'Wyeast 1056 - American Ale™'},'food_pairing':['Bratwurst sausage with spicy mustard','Fried American bacon with chilli flakes added to the top','Dark chocolate chip cookies'],'brewers_tips':'Use the freshest hops for the most impact. It seems obvious but in a single hop beer, you want the hops to be at their best.','contributed_by':'Sam Mason <samjbmason>'}]";

            var result = BeerModelMapper.ConvertResonseToBeerDetail(model);

            Assert.IsNotNull(result);
            Assert.AreSame(55, result.Id);
        }

        public void TestConvertParamsToBeerByName()
        {

            var name = "someName";
            var page = 1;
            var take = 10;
            var result = BeerModelMapper.ConvertParamsToBeerByName(name,page,take);
            Assert.AreSame(name, result.beerName);
        }
    }
}
