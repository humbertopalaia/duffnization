console.log('Definindo constantes');

const routerConfig = require('./infra/router-config');

const express = require('express');
const app = express();         
const bodyParser = require('body-parser');
const porta = 8000; //porta padrão

console.log('Constantes definidas');

// Starting point of the server
function main () {
	
	console.log('Definindo configurações básicas');

	let app = express(); // Export app for other routes to use
	const port = process.env.PORT || porta;

	app.use(bodyParser.urlencoded({ // Middleware
		extended: true
	}));
	
	app.use(bodyParser.json());
	
	console.log('Configurações básicas definidas');
	
	
	console.log('Definindo rotas');
	
	routerConfig.configureRoutes(app, function()
	{
		console.log('Rotas definidas');

		app.listen(port, () => {
			console.log(`Servidor está escutando a porta: ${port}`, true);		
		});

	});
}

main();
