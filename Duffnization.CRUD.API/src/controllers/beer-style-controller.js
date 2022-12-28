const beerStyleService = require('../services/beer-style-service');

module.exports = {

    listAll: function (req, res) {

        beerStyleService.listAll((list) => {
            res.send(list);
        })
    },

    getById(req, res)
    {
        if (req.params.id) {
            beerStyleService.getById(req.params.id, (beetStyle) => {
                if (beetStyle != null)
                    res.send(beetStyle);
                else
                    res.status(401).send('id not found');
            })
        }
        else
            res.status(403).send('id not supplied');
    },

    getByTemperature(req, res)
    {
        if (req.query.temperature) {
            beerStyleService.getByTemperature(req.query.temperature, (list) => {
                if (list != null)
                    res.send(list);
                else
                    res.status(401).send('No data found');
            })
        }
        else
            res.status(403).send('temperature not supplied');
    },

    insert(req,res)
    {
        beerStyleService.insert(req.body, (result) => {
            res.send(result);
        });
    },
    delete(req,res)
    {
        
        if (req.params.id) {

               
            beerStyleService.delete(req.params.id, function(err)
            {
                if (err) {
                    res.status(500).send('internal server error');
                    console.log(err);
                }
                else
                    res.status(200).send('success');    
            });
        }
        else
           res.status(400).send('Parâmetro id é obrigatório');
    },
    update(req,res)
    {
        
        if (req.body != null) {
            beerStyleService.update(req.body, function (err) {
                if (err) {
                    res.status(500).send('internal server error');
                    console.log(err);
                }
                else
                    res.status(200).send('success');
            });

        }
        else
            res.status(400).send('invalid payload');
    }
};