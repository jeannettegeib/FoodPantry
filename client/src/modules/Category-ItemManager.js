export const getAllCategories=()=>{
    return fetch(`https://localhost:5001/api/Category`)
    .then ((r)=>r.json())
}
export const submitCategoryItems=(orderItem)=>{
    return fetch(`https://localhost:5001/api/OrderItem`,{
    method: "POST",
        headers:{
            "Content-type":"application/json"
        },
        body: JSON.stringify(orderItem)
    })
    .then(r=>r.json())

}