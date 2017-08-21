const request = require('request');
const {forEach, set} = require('lodash');
const cheerio = require('cheerio');
const googleUrlPath = 'https://google.com/search?q=';

const requestOpt = {
  timeout: 500000, 
  headers: {
    'User-agent': 'google-bot'
  },
  transform(body) {
    return cheerio.load(body, { xmlmode: true });
  }
 }

const getSearchResult = (searchTerms)=>{
  var searchUrl = `${googleUrlPath}${searchTerms}`;
  var resultObj = {}
  request.get(searchUrl, requestOpt, (err, response, results)=>{
    if(err){
      throw err;
    }
    $ = cheerio.load(results);
    const links = $('h3[class=r] a').toArray();
    forEach(links, (link)=>{
      set(resultObj, 'search-links', link.attribs.href);
    })
    console.log(resultObj);
  });
}

getSearchResult('Nodejs docs');