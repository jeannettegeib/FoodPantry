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

export const ListActiveOrders =()=>{
    return fetch(`https://localhost:5001/api/Order`)
    .then(r=>r.json())
}

export const SubmitOrder=(order)=>{
    return fetch(`https://localhost:5001/api/Order/${order.Id}`,{
    method: "PUT",
    headers:{
        "Content-type":"application/json"
    },
    body:JSON.stringify(order)
    })
    .then(r=>r.JSON())
}

export const getOrderById=(id)=>{
    return fetch(`https://localhost:5001/api/Order/${id}`)
    .then(r=>r.JSON())
}