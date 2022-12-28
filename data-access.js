//var sql = require('msnodesqlv8');
const sql = require('mssql')

const sqlConfig = {
	user: 'sa',
	password: '@sa123456',
	database: 'Duffnization',
	server: 'localhost',
	port: 1433,
	options: {
	  trustServerCertificate: true, // change to true for local dev / self-signed certs
	  enableArithAbort : true
	}
  }

module.exports = {
	execQuery: async function (sqlQry, callBack) {
		
		try {
			await sql.connect(sqlConfig)
			const result = await sql.query(sqlQry);
			callBack(result.recordset);
		} catch (err) {
			console.log(err);			
		}
	}
};

