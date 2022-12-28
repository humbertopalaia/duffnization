const dataAccess = require('./data-access');


module.exports = {

  listAll: function (callBack) {        
    dataAccess.execQuery('SELECT * FROM CoffeStyle', callBack);
  },
  getById : function(id, callBack)
  {
    dataAccess.execQuery(`SELECT * FROM CoffeStyle WHERE Id = ${id}`, function(result)
    {
      if(result  && result.length > 0)
        callBack(result[0]);
      else
        callBack(null);
    });
  }
};
