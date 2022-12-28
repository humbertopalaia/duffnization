//var sql = require('msnodesqlv8');
const sql = require('mssql')
require('dotenv').config();


const sqlConfig = {
	user: `${process.env.USERDB}`,
	password: `${process.env.PASSWORDDB}`,
	database: `${process.env.INITIALCATALOGDB}`,
	server: `${process.env.SERVERDB}`,
	port: parseInt(process.env.PORTDB),
	options: {
		trustServerCertificate: true, // change to true for local dev / self-signed certs
		enableArithAbort: true
	}
}

console.log(sqlConfig);

module.exports = {
	execQuery: async function (sqlQry, callBack) {

		try {
			await sql.connect(sqlConfig)
			const result = await sql.query(sqlQry);
			callBack(result.recordset);
		} catch (err) {
			callBack(null, err);
		}
	},
	execQueryParam: async function (query, params, callBack) {

		try {

			let poolConnection = {};
			await sql.connect(sqlConfig)
			.then(pool => {
				poolConnection = pool;
			});

			const request = poolConnection.request();
			

			params.forEach(param => {
				request.input(param.name, param.value);
			});

			const result = await request.query(query);
	
			callBack(result.recordset);

		} catch (err) {
			callBack(null, err);
		}
	}
};

