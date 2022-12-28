const { TYPES } = require('tedious');
const dataAccess = require('./data-access');


module.exports = {

  listAll: function (callBack) {        
    dataAccess.execQuery('SELECT Id, Name, Active, MinTemperature, MaxTemperature, CreateDate, UpdateDate FROM CoffeStyle', callBack);
  },
  getById : function(id, callBack)
  {
    dataAccess.execQuery(`SELECT Id, Name, Active, MinTemperature, MaxTemperature, CreateDate, UpdateDate FROM CoffeStyle WHERE Id = ${id}`, function(result)
    {
      if(result  && result.length > 0)
        callBack(result[0]);
      else
        callBack(null);
    });
  },
  insert: function(coffeStyle, callBack)
  {
    let params = [];
    params.push({name:'name', type:TYPES.VarChar, value: coffeStyle.name});
    params.push({name:'active', type:TYPES.Bit, value: coffeStyle.active});
    params.push({name:'minTemperature', type:TYPES.SmallInt, value: coffeStyle.minTemperature});
    params.push({name:'maxTemperature', type:TYPES.SmallInt, value: coffeStyle.maxTemperature});

    dataAccess.execQueryParam('INSERT INTO CoffeStyle ([Name], Active, MinTemperature, MaxTemperature, CreateDate) OUTPUT INSERTED.* VALUES(@name, @active, @minTemperature, @maxTemperature, GETDATE())', params, function(result)
    {
      if(result  && result.length > 0)
        callBack(result[0]);
      else
        callBack(null);
    });


  }
};
