export const OpenEmptyOrderForShopper =(order)=>{
    return fetch(`https://localhost:5001/api/Order`, {
        method: "POST",
        headers:{
            "Content-type":"application/json"
        },
        body: JSON.stringify(order)
    })
    .then(r=>r.json())
}