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
    .then(r=>r.json())
}

export const getOrderById=(orderId)=>{
    return fetch(`https://localhost:5001/api/Order/${orderId}`)
    .then(r => r.json())
}

export const getOrderByIdWithItems=(orderId)=>{
    return fetch(`https://localhost:5001/api/Order/GetWithItems/${orderId}`)
    .then(r => r.json())
}