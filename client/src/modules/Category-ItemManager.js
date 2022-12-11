export const getAllCategories=()=>{
    return fetch(`https://localhost:5001/api/Category`)
    .then ((r)=>r.json())
}