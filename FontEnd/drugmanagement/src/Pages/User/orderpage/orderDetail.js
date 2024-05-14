
import { memo, useEffect } from 'react';
import './style.scss';
import { useState } from 'react';
import NotFound404 from '../../NotFound404';
import { DecodeToken } from '../../../Utils/DecodeToken';
import axios from 'axios';
import { APIGATEWAY, ROUTER } from '../../../Utils/Router';
import { useParams } from 'react-router-dom';


const OrderDetailUser = () => {
    const token = localStorage.getItem('token');
    const [listOrder, setListOrder] = useState([]);
    let decodeToken = null;
    if ( token !== null && token !== "null" && token !== "" & token !== undefined ) {
        decodeToken = DecodeToken(token);
    }
    const { id } = useParams();

    useEffect(() => {
        if (token !== null && token !== "null" && token !== "" & token !== undefined && decodeToken!==null) {
            return <NotFound404 />;
        } 
        //const username = decodeToken.username;
        axios.get(APIGATEWAY.ORDERDETAIL.BYORDERID + id, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            }
        }).then(respone => {
            setListOrder(respone.data);
        }).catch(error => {
            console.log("Lỗi ", error);
            return <NotFound404 />;
        });
    },[token])
    
    return (
        <div className="container">
            <div className="row">
                <div className="order-detail">
                    <h1>Chi tiết hoá đơn: {id}  </h1>
                    <table>
                        <thead>
                            <tr>
                                <th>Product ID</th>
                                <th>Quantity</th>
                                <th>Total Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            {listOrder.map(order => (
                                <tr key={order.productId}>
                                    <td>{order.productId}</td>
                                    <td>{order.soLuong}</td>
                                    <td>{order.thanhTien}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <div className="btn">
            <button onClick={() => { window.location.href = ROUTER.USER.HOME }}>Về trang chủ</button>

            </div>
        </div>
    );
}
export default memo(OrderDetailUser);