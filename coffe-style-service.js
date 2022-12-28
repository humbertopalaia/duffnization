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
  }
};
