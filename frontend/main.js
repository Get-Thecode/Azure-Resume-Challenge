window.addEventListener('DOMContentLoaded', (event)=>{
    getVisitCount();
})

const functionApiUrl = 'https://getcounterresume.azurewebsites.net/api/GetResumeCounter?code=R7hke_bRZGxsOoa_nGC9L1c2_s9uUKCkYUnvm4jMcYcxAzFu3G8--A%3D%3D';
const localfunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API");
        count = response.count;
        document.getElementById("counter").innerText = count;
    });
    return count;
}