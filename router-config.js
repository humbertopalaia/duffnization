const coffeStyleService = require('./coffe-style-service');

module.exports = {
  configureRoutes: function (app, callBack) {

    app.get('/coffe-style/listAll', (req, res) =>
    {    
        coffeStyleService.listAll((list) =>
        {            
            res.send(list);
        })
    });			

    app.get('/coffe-style/getById/:id?', (req, res) =>
    {    
        if(req.params.id)
        {
            coffeStyleService.getById(req.params.id, (list) =>
            {            
                res.send(list);
            })
        }
        else
            res.send('Parâmetro id é obrigatório');
        
    });
    
    // app.post('/amigo/novo', middleware.checkToken, (req, res, next) => {
	// 	amigo.incluir(req.body, function(results)
	// 	{
	// 		res.json(results);
	// 	});	
	// });
    

    // app.post('/amigo/apagar', middleware.checkToken, (req, res, next) => {
    //     amigo.apagar(req.body, function(results)
	// 	{
    //         if(results.sucesso)
    //         {
    //             res.json(results);
    //         }
    //         else
    //         {
    //             res.status(400).json(results);
    //         }
	// 	});

    // });
    

    // app.get('/amigo/:petId?/:nome?', middleware.checkToken, (req, res, next) => {

	// 	amigo.listar(req.params.petId, req.params.nome, function(results)
	// 	{
	// 		res.json(results);

	// 	});
	// });


	
    // -------------------------------------------


    callBack();
  }
};
