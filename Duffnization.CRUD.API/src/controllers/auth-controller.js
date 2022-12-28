let jwt = require('jsonwebtoken');
require('dotenv').config();

module.exports = {
    authenticate: function (req, res) {
        let username = req.body.username;
        let password = req.body.password;

        if (username == process.env.JWTUSER && password == process.env.JWTPASSWORD) {

            let token = jwt.sign({ username: username },
                process.env.JWTSECRET,
                {
                    expiresIn: '24h' // expires in 24 hours
                }
            );
            // return the JWT token for the future API calls
            res.send({
                success: true,
                message: 'Authentication successfully',
                token: token
            });
        }
        else {
            res.status(401).json({
                success: false,
                message: 'Invalid credentials'
            });
        }
    }
};