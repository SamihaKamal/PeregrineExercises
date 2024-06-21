var express = require("express");
const cors = require("cors");
var bodyparser = require("body-parser");
var sql = require("mssql");
var app = express();
const path = require('path');
var form = require('multer');
const { json } = require("body-parser");
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');

const ip ='127.0.0.1';
const port = '4040';

//Body parser middleware
//Body parser, as its name suggests, parses request bodies that come through.
app.use(bodyparser.json());
app.use(bodyparser.urlencoded({ extended: false }));
var urlencodedParser = bodyparser.urlencoded({ extended: false });
app.use(bodyparser.text({ type: 'text/html' }));

app.use(cors({
    origin: "*",
    methods: ['GET','POST']
}));

app.use(express.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, 'css')));


//CORS MIDDLEWARE
//cors is about resource sharing and control how different places access a resource.
app.use(function(req,res,next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With,contentType,Content-Type,Accept,Authorization");
    next();
});

//server set up
var server = app.listen(process.env.PORT || 4040, function(){
    var port = server.address().port;
    console.log("App now running on port ", port);
    console.log(`server running at http://${ip}:${port}/`);
})

var dbConfig = {
    user:"sa",
    password:"1234",
    server:"DESKTOP-PCDU919",
    database:"Node",
    synchronize:true,
    trustServerCertificate:true,
    port:1433,
    dialectOptions:{
        instanceName:"SQLExpress"
    }
};

var items = [];
var item = [];
var items2 = [];
var item2 = [];

app.get("/", function(req,res){
    var query = "select * from StudentInfo";
    sql.connect(dbConfig, function(err){
        if (err) console.log(err)
        var request = new sql.Request();
        request.query(query, function(err, recordset){
            if (err) console.log(err)
            for (let [key, value] of Object.entries(recordset)){
                if(key === "recordset"){
                    items = [];
                    for (var i=0; i< value.length; i++){
                        item =[];
                        item['id'] = value[i].ID;
                        item['name'] = value[i].Name;
                        item['age'] = value[i].Age;
                        items.push(item);
                    }
                }else{
                }
            }
            console.log('---------------------------------')
            res.render('index', {title: 'items', items: items});
            res.end;
        });
    });
});

//POST API
app.post("/user", function(req,res){
    userid = req.body["dropDown"];
    var query = "select * from StudentInfo where ID = " + "'"+ userid[0] + "'";
    sql.connect(dbConfig, function (err){
        if (err) console.log(err)
        var request = new sql.Request();
        request.query(query, function(err, recordset){
            if (err) console.log(err)
            for(let [key,value] of Object.entries(recordset)){
                if(key==="recordset"){
                    items =[]
                    for(var i=0; i<value.length; i++){
                        item=[];
                        item['id'] = value[i].ID;
                        item['name'] = value[i].Name;
                        item['age'] = value[i].Age;
                        items.push(item);
                    }
                }else{
                }
            }
            if(items.length > 0){
            }else{
            }

            res.render('table', {title: 'items', items:items});
            res.end;
        });
    });
});

//PUT API
app.put("/user/:id", function(req,res){
    const userid = req.params.id;
    const name = req.body.Name;
    const age = req.body.Age;
    var query = "update StudentInfo set Name=@name, Age=@age where ID=@id ";
    sql.connect(dbConfig, function (err){
        if (err) console.log(err)
        var request = new sql.Request();
        request.input('Name', sql.VarChar, name);
        request.input('Age', sql.Int, age);
        request.input('ID', sql.Int, userid);
        request.query(query, function(err, recordset){
            if (err){
                console.log(err)
            } else{
                res.status(200).send('User updated successfully');
            }
        });
    });
});

//DELETE API
app.delete("/user/:id", function(req,res){
    const userid = req.params.id;
    var query = "delete from StudentInfo where ID=@id ";
    sql.connect(dbConfig, function (err){
        if (err) console.log(err)
        var request = new sql.Request();
        request.input('ID', sql.Int, userid);
        request.query(query, function(err, recordset){
            if (err){
                console.log(err)
            } else{
                res.status(200).send('User deleted successfully');
            }
        });
    });
});
