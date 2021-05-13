const main = () => {
    "use strict";
    window.addEventListener("DOMContentLoaded", () => {
        const tabcontent = document.querySelectorAll(".tab-content"),
              tabheaderitems = document.querySelectorAll(".tabheader-items");
        tabheaderitems.forEach((item,i) => {
            item.addEventListener("click", () => {
                tabcontent.forEach(e => makeInvisible(e));
                makeVisible(tabcontent[i]);
                tabheaderitems.forEach(e => e.classList.remove("active"));
                item.classList.add("active");
            });
        });
    });
    function makeVisible(element){
        element.classList.remove("hide");
        element.classList.add("show");
    }
    function makeInvisible(element){
        element.classList.remove("show");
        element.classList.add("hide");
    }
};

// let a = 5;
// let b = "5";
// console.log(a == b);
// console.log(a === b);
main();

class Test{
    constructor(){
        this.name = "test";
    }
    t(){
        const t = function(){
            console.log(this.name);
        }
        t();
    }
    p(){
        console.log("inside");
        const t = () => {
            console.log(this.name+"arrow");
        }
        t();
    }
}

const obj = new Test();
obj.p();
