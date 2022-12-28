const beerStyleService = require('../services/beer-style-service');
const beerStyleController = require('../controllers/beer-style-controller');


module.exports = {
    configureRoutes: function (app, callBack) {

        //beet-style
        app.get('/beer-style/listAll', (req, res) => {
            beerStyleController.listAll(req,res);
        });

        app.get('/beer-style/getById/:id?', (req, res) => {
            beerStyleController.getById(req,res);
        });

        app.put('/beer-style/insert', (req, res) => {
            beerStyleController.insert(req,res);          
        });

        app.delete('/beer-style/delete/:id?', (req, res) => {
            beerStyleController.delete(req,res);          
        });

        app.post('/beer-style/update', (req, res) => {
            beerStyleController.update(req,res);          
        });
        //----------------------------------------------
        


        callBack();
    }
};
