const { version } = require("react");

let name="Shashank";
var a =`I am ${name}`;
console.log(a);

//Hoisting
//Var and function declaration is moved to the top
abc();
function abc(){
    console.log(abc);
}

console.log(s);

var s;

//Let const and var
{
    let letTemp=1;
    const constTemp=2;
    var varTemp=3
    console.log(letTemp);
    console.log(constTemp);
    console.log(varTemp);
}
//console.log(letTemp);
//    console.log(constTemp);
console.log(varTemp);
function abc(){
    var s=1;
}
console.log(s);  //--------------------IMp: undefined

//Array
var array1=["Hello",1,true,'a','123'
];
for(let i=0;i<array1.length;i++){
    console.log(array1[i]);
}
console.log("Using Map:");
array1.map(function(x){console.log(x)});
console.log("Using Map to print only numbers:");
array1.map((x)=>{
    if(typeof x =="number"){
        console.log(x)
    }
})

if(!isNaN(array1[array1.length-1])){
    console.log("--------------------It is a number----------------------");
}



//Event Capturing and Event Bubling
//document.getElementById('innerdiv').addEventListener
//("click",function(){
//    console.log("hello World")
//},true)

//IIFE
(function(){
    console.log("hello world");
})();

const timerId=setTimeout(() => {
console.log("After 5 sec")    
}, 5000);


//Generator function
console.log("Generator function")
function* InfiniteSequence(){
    let counter=0;
    while(true){
        yield counter;
        counter++;
    }
}
const tempGenerator=InfiniteSequence();
console.log(tempGenerator.next().value);

console.log(tempGenerator.next().value);


//WeakMap
const weakMap=new WeakMap();
//Store private data tied to an object, without causing memory leaks.
let obj={
    id:1,
    name:"Shashank",
};
weakMap.set(obj,"Hello");
//obj=null;
console.log(weakMap.get(obj));

//Higher Order Function
function Greece(name){
console.log("Hell0 ",name)
}
function Greet(fn, gre){
    console.log(fn(gre))
}
Greet(Greece,"Java")


//Closure
console.log("closure");
function createBankAccount(){
    let currentBalance=1000;
    return {
        deposit(amount){
            currentBalance+=amount;
            return currentBalance;
        },
        withdraw(amount){
            currentBalance-=amount;
            return currentBalance;
        }
    }
}
const bankaccount=createBankAccount();
console.log(bankaccount.deposit(100));
console.log(bankaccount.withdraw(100));


//Event delegation in JavaScript is a technique where you attach a single event listener to a parent element to handle events on its child elements, instead of attaching separate listeners to each child.
/*
const list=document.getElementById("UL");
list.addEventListener("click",function(event){
    if(event.target.tagName="LI"){
        console.log(event.target.textContent);
    }
})
*/




