
async function GetResources(url = ''){
    const temp = await fetch(url);
    const json = await temp.json();
    return json;
}

async function PostResources(url, post){
    const temp = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(post)
    });
    return await temp.json();
}

document.addEventListener("DOMContentLoaded" , async () => {
     const data = await GetResources("https://jsonplaceholder.typicode.com/todos/1");
     const obj = JSON.parse(data);
     const response = await PostResources("https://jsonplaceholder.typicode.com/todos/", obj);
     console.log(data);
});


// const temp = async () => {
//     const data = await GetResources();
//     console.log(data);
// }

// const temp1 = () => fetch('https://jsonplaceholder.typicode.com/posts/1')
// .then(response => response.json())
// .then(json => console.log(json));

// const response = axios.get("https://jsonplaceholder.typicode.com/posts/1")
//         .then(data => console.log(typeof(data.data)));

