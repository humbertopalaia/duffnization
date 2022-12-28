const beerStyleService = require('../services/beer-style-service');
const beerStyleController = require('../controllers/beer-style-controller');
const authController = require('../controllers/auth-controller');
const middleware = require('./middleware');


module.exports = {
    configureRoutes: function (app, callBack) {

        //auth
        app.post('/auth/login', (req, res) => {
            authController.authenticate(req,res);
        });

        //-------------------------------------------

        //beet-style
        app.get('/beer-style/listAll', middleware.checkToken, (req, res) => {
            beerStyleController.listAll(req,res);
        });

        app.get('/beer-style/getById/:id?', middleware.checkToken,(req, res) => {
            beerStyleController.getById(req,res);
        });

        app.get('/beer-style/getByTemperature', (req, res) => {
            beerStyleController.getByTemperature(req,res);
        });


        app.put('/beer-style/insert', middleware.checkToken,(req, res) => {
            beerStyleController.insert(req,res);          
        });

        app.delete('/beer-style/delete/:id?', middleware.checkToken,(req, res) => {
            beerStyleController.delete(req,res);          
        });

        app.post('/beer-style/update', middleware.checkToken,(req, res) => {
            beerStyleController.update(req,res);          
        });
        //----------------------------------------------
        


        callBack();
    }
};
