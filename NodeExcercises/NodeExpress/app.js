var express = require('express');
var app = express();
app.get('/',function(req, res) {
    var sql = require("mssql");
    var config ={
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

    sql.connect(config,function(err){
        if (err) console.log(err);
    
        var request = new sql.Request();
    
        request.query('select * from StudentInfo', function(err, recordset){
            if (err) console.log(err)
            res.send(recordset);
        });
    });
});

var server = app.listen(5000, function (){
    console.log('server is running...');
});

