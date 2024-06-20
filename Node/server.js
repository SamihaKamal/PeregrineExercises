const http = require('http');
const fs = require('fs');
var cors = require('cors');
var express = require('express');
var app = express();

app.get('/', function(req,res) {
    res.sendFile(__dirname + '/index.html');
})
app.get('/index.html', function(req,res) {
    res.sendFile(__dirname + '/index.html');
})
app.get('/pagetwo.html', function(req,res) {
    res.sendFile(__dirname + '/pagetwo.html');
})
app.get('/pagethree.html', function(req,res) {
    res.sendFile(__dirname + '/pagethree.html');
})

var server = app.listen(3000, function(){
    var host = server.address().address
    var port = server.address().port
    console.log("App is listening at http://%s:%s",host,port)
});