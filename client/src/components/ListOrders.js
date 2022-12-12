import { Card } from "reactstrap"
import { ListActiveOrders } from "../modules/OrderManager"

export const ListOrders=()=>{
    const [orders, setOrders]=useState()

    useEffect(()=>{
        ListActiveOrders()
        .then((r)=>{setOrders(r)})
    },[])

    return(
        <>
        <h1> Upcoming Orders</h1>
       
        {orders.map((order)=>{
            return(
                <Card>{order.PickupDate}</Card>
                )
        })}
        </>
    )
}