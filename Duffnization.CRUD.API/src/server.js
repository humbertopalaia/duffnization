console.log('Configuring constants');

const routerConfig = require('./infra/router-config');

require('dotenv').config();
const express = require('express');

const app = express();         
const bodyParser = require('body-parser');
const port = process.env.SERVERPORT || 8000;

console.log('Constants configured');

// Starting point of the server
function main () {
	
	console.log('Starting main process');
	let app = express(); // Export app for other routes to use

	app.use(bodyParser.urlencoded({ // Middleware
		extended: true
	}));
	
	app.use(bodyParser.json());
	
	console.log('Configuring routes');
	
	routerConfig.configureRoutes(app, function()
	{
		console.log('Routes configured');

		app.listen(port, () => {
			console.log(`Server listening port: ${port}`, true);		
		});

	});
}

main();
