/*server.js*/
const http=require('http');
const ip='127.0.0.1';
const port='3000';
const server=http.createServer((req,res)=>{
    res.write("hello node");
    res.end();
});
server.listen(port,ip,()=>{
    console.log(`server running at http://${ip}:${port}/`);
});