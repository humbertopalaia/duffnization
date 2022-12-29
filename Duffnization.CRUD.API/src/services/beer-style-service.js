const { TYPES } = require('tedious');
const dataAccess = require('../infra/data-access');

const lodash = require('lodash');

module.exports = {

  listAll: function (callBack) {
    dataAccess.execQuery('SELECT id, name, minTemperature, maxTemperature, ((minTemperature+maxTemperature)/2) averageTemperature, createDate, updateDate FROM BeerStyle', callBack);
  },
  getById: function (id, callBack) {
    dataAccess.execQuery(`SELECT id, name, minTemperature, maxTemperature, createDate, updateDate FROM BeerStyle WHERE Id = ${id}`, function (result) {
      if (result && result.length > 0)
        callBack(result[0]);
      else
        callBack(null);
    });
  },
  insert: function (beerStyle, callBack) {
    let params = [];
    params.push({ name: 'name', type: TYPES.VarChar, value: beerStyle.name });
    params.push({ name: 'minTemperature', type: TYPES.SmallInt, value: beerStyle.minTemperature });
    params.push({ name: 'maxTemperature', type: TYPES.SmallInt, value: beerStyle.maxTemperature });

    dataAccess.execQueryParam('INSERT INTO BeerStyle (name, minTemperature, maxTemperature, createDate) OUTPUT INSERTED.* VALUES(@name, @minTemperature, @maxTemperature, GETDATE())', params, function (result) {
      if (result && result.length > 0) {
        let resultCamelCase = Object.entries(result[0]).reduce((obj, [key, value]) => {
          obj[lodash.camelCase(key)] = value; return obj;
        }, {});

        callBack(resultCamelCase);
      }
      else
        callBack(null);
    });
  },
  delete: function (id, callBack) {
    dataAccess.execQuery(`DELETE FROM BeerStyle Where id = ${id}`, function (err) {
      callBack(err);
    });
  },
  update: function (beerStyle, callBack) {
    let sqlCommand = `UPDATE BeerStyle 
                      SET 
                        name = '${beerStyle.name}',
                        minTemperature = ${beerStyle.minTemperature},
                        maxTemperature = ${beerStyle.maxTemperature},
                        updateDate = GETDATE()
                      WHERE id = ${beerStyle.id}  
                        `;

    dataAccess.execQuery(sqlCommand, function (result, err) {
      callBack(err);
    });


  }
};
