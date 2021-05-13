/* jshint node: true */

const req = new Promise((resolve, reject) => {
    setTimeout(() => {
        console.log("подготавливаем данные...");

        const obj = {
            name: "Test",
            descr: "Testing"
        };

        resolve(obj);
    }, 2000);
});

req.then(obj => {
    console.log("just recieved an object.");
    console.log(obj);
    return new Promise((resolve, reject) => {
        console.log("start modification");
        obj.status = "modified";
        resolve(obj);
    });
}).then(obj => {
    console.log("getting the modified object");
    console.log(obj);
    return obj;
}).then(obj => {
    console.log("synchronous");
});
