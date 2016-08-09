// Get all the packages we need
var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var morgan = require('morgan');
var mongoose = require('mongoose');


var jwt = require('jsonwebtoken');
var config = require('./config/config');
var User = require('./app/models/user');


// Basic configuration
var port = process.env.PORT || 8080;
mongoose.connect(config.database);
app.set('superSecret', config.secret);

// Use body parse to get info from POST and.or URL Parameters
app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

// Morgan to log requests to console
app.use(morgan('dev'));

// Test Route: Demo
app.get('/', function(req, res){
    res.send('IReach API is at http://localhost:' + port + '/api');
});




// API Setup Create a Test User:
app.get('/setup', function(req, res){
    
    // Create a sample user
    var tino = new User({
        name : 'tino',
        password: 'Holl619ic',
        admin: true
    });
    
    tino.save(function(err){
        if(err) throw err;
        
        console.log('User created successfully....');
        res.json({success: true, msg: 'User Created Successfully'});
    });
});

// API ROUTES:
var apiRoutes = express.Router();

// TODO: route to authenticate a user (POST http://localhost:8080/api/authenticate)
apiRoutes.post('/authenticate', function(req, res){
    
    // Find the user
    User.findOne({
        name: req.body.name
    }, function(err, user){
        if(err) throw err;
        
        if(!user){
            res.json({success: false, message: 'Authentication failed: User does not exists.'});
        } else if (user){
            
            // Check if passwords match
            if(user.password != req.body.password){
                res.json({success: false, message: 'Authentication failed: Wrong password'})
            } else {
                
                // User is found and password is correct
                var token = jwt.sign(user, app.get('superSecret'), {
                    expiresIn: 1440  // 24 Hours expiration
                });
                
                // Return the information including token as JSON
                res.json({
                    success: true,
                    message: 'Enjoy a Token from US!',
                    token  : token
                });
            }
        }
    });
});


// TODO: route middleware to verify a token


// Return All USERS: GET http://localhost:8080/api/users
apiRoutes.get('/users', function(req, res){
    User.find({}, function(err, users){
        res.json(users);
    });
});


apiRoutes.get('/', function(req, res){
    res.json({message: "Welcome to IReachAPI CS421 Senior Design Project"});
});

// route to show a random message 


// apply the routes to our application with the prefix /api
app.use('/api', apiRoutes);

// Start the server
app.listen(port);
console.log('IReach rules the world at http://localhost:'+ port);
