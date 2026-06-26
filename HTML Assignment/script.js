const originalFlights=[
{time:"15:05",flight:"NH 0175",dest:"TOKYO",gate:"D02",status:"DEPARTED"},
{time:"15:15",flight:"WN 0612",dest:"LAS VEGAS",gate:"B09",status:"DEPARTED"},
{time:"12:59",flight:"F9 1635",dest:"BOSTON",gate:"B05",status:"GATE CLOSED"},
{time:"13:11",flight:"AS 3188",dest:"NEW YORK",gate:"D12",status:"GATE CLOSED"},
{time:"13:37",flight:"BA 1760",dest:"SAN FRANCISCO",gate:"B20",status:"DELAYED"},
{time:"12:40",flight:"AA 8826",dest:"CHICAGO",gate:"A11",status:"ON TIME"},
{time:"12:50",flight:"F9 0970",dest:"LONDON",gate:"C11",status:"BOARDING"},
{time:"13:50",flight:"DL 2330",dest:"SAN FRANCISCO",gate:"A04",status:"DEPARTED"},
{time:"14:26",flight:"AC 0202",dest:"LONDON",gate:"C14",status:"GATE CLOSED"}
];

let flights=JSON.parse(JSON.stringify(originalFlights));

const board=document.getElementById("board");

function statusClass(status){

if(status==="ON TIME") return "on-time";
if(status==="BOARDING") return "boarding";
if(status==="DELAYED") return "delayed";
if(status==="GATE CLOSED") return "closed";
return "departed";

}

function createRow(flight,index){

const row=document.createElement("div");
row.className="row fade";
row.dataset.index=index;

const time=document.createElement("div");
time.className="cell";
time.textContent=flight.time;

const no=document.createElement("div");
no.className="cell";
no.textContent=flight.flight;

const dest=document.createElement("div");
dest.className="cell destination";
dest.textContent=flight.dest;

const gate=document.createElement("div");
gate.className="cell";
gate.textContent=flight.gate;

const status=document.createElement("div");
status.className="cell status "+statusClass(flight.status);
status.textContent=flight.status;

row.appendChild(time);
row.appendChild(no);
row.appendChild(dest);
row.appendChild(gate);
row.appendChild(status);

board.appendChild(row);

}

function render(){

board.textContent="";

flights.forEach((flight,index)=>{

createRow(flight,index);

});

updateSummary();

}

function updateSummary(){

const boarding=flights.filter(f=>f.status==="BOARDING").length;
const delayed=flights.filter(f=>f.status==="DELAYED").length;

document.getElementById("summary").textContent=
`${flights.length} departures · ${boarding} boarding · ${delayed} delayed`;

}

document.getElementById("addBtn").addEventListener("click",()=>{

const n=flights.length+1;

flights.push({
time:"16:"+String(Math.floor(Math.random()*60)).padStart(2,"0"),
flight:"UA "+Math.floor(Math.random()*9000+1000),
dest:"MIAMI",
gate:"A"+Math.floor(Math.random()*20),
status:"ON TIME"
});

render();

});

document.getElementById("resetBtn").addEventListener("click",()=>{

flights=JSON.parse(JSON.stringify(originalFlights));

render();

});

function updateClock(){

const now=new Date();

document.getElementById("clock").textContent=
now.toLocaleTimeString("en-US",{hour12:false});

}

updateClock();

setInterval(updateClock,1000);

const order=["ON TIME","BOARDING","GATE CLOSED","DEPARTED"];

setInterval(()=>{

const index=Math.floor(Math.random()*flights.length);

const flight=flights[index];

if(flight.status==="DELAYED"){

flight.status="BOARDING";

}else{

const current=order.indexOf(flight.status);

if(current<order.length-1){

flight.status=order[current+1];

}

}

const row=document.querySelector(`[data-index="${index}"]`);

const cell=row.children[4];

cell.textContent=flight.status;
cell.className="cell status "+statusClass(flight.status);

updateSummary();

},4000);

render();