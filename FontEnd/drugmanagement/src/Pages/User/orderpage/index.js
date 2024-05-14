//import { memo, useEffect, useState } from 'react';
//import NotFound404 from '../../NotFound404';
//import { DecodeToken } from '../../../Utils/DecodeToken';
//import axios from 'axios';
//import { APIGATEWAY, ROUTER } from '../../../Utils/Router';
//import { wait } from '@testing-library/user-event/dist/utils';
//import './style.scss';

//const OrderUser = () => {
//    const token = localStorage.getItem('token');
//    const [orders, setOrders] = useState([]);
//    useEffect(() => {
//        if (token === null) {
//            return <NotFound404 />
//        }

//        const decodeToken = DecodeToken(token);
//        const username = decodeToken.username;

//        axios.wait.get(APIGATEWAY.ORDER.BYUSERID + username, {
//            headers: {
//                'Content-Type': 'application/json',
//                'Authorization': 'Bearer ' + token
//            }
//        }).then(respone => {
//            setOrders(respone.data).catch(error => { console.error("Lỗi :", error); return <NotFound404 /> });
//        })

//    }, [token]);

//    if (orders === null || Array(orders.length) === null) {
//        return <NotFound404/>
//    }


//    return (
//        <div className="container">
//            <div className="row">
//                <div className="order">
//                    <table>
//                        <thead>
//                            <tr>
//                                <th>ID</th>
//                                <th>User ID</th>
//                                <th>Ngày</th>
//                                <th>Tổng Tiền</th>
//                            </tr>
//                        </thead>
//                        <tbody>
//                            {orders.map(item => (
//                                <tr key={item.id}>
//                                    <td>{item.id}</td>
//                                    <td>{item.userId}</td>
//                                    <td>{item.ngay}</td>
//                                    <td>{item.tongTien}</td>
//                                </tr>
//                            ))}
//                        </tbody>
//                    </table>
//                </div>
//            </div>
//        </div>
//    );
//};

//export default memo(OrderUser);


import { memo, useEffect, useState } from 'react';
import NotFound404 from '../../NotFound404';
import { DecodeToken } from '../../../Utils/DecodeToken';
import axios from 'axios';
import { APIGATEWAY, ROUTER } from '../../../Utils/Router';
import './style.scss';
import { Formater } from '../../../Utils/formater';
import { Link } from 'react-router-dom';

const OrderUser = () => {
    const token = localStorage.getItem('token');
    const [orders, setOrders] = useState([
        { id: 1, userId: 1, ngay: '2024-05-13', tongTien: 1000000,trangThai:"Đã giao" },
        { id: 2, userId: 2, ngay: '2024-05-14', tongTien: 2000000 ,trangThai: "Đang giao" },
        { id: 3, userId: 1, ngay: '2024-05-15', tongTien: 1500000, trangThai: "Chờ duyệt" },
    ]);

    useEffect(() => {
        if (token === null) {
            return <NotFound404 />
        }

        const decodeToken = DecodeToken(token);
        const username = decodeToken.username;

        axios.get(APIGATEWAY.ORDER.BYUSERID + username, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            }
        }).then(response => {
            setOrders(response.data);
        }).catch(error => { console.error("Lỗi :", error); return <NotFound404 /> });

    }, [token]);

    if (orders === null || orders.length === 0) {
        return <NotFound404 />
    }

    return (
        <div className="orderpage">
        <div className="container">
            <div className="row">
                <div className="order">
                <h1>Lịch sử đơn hàng</h1>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Ngày</th>
                                <th>Tổng Tiền</th>
                                <th>Trạng Thái</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(item => (
                                <Link to={`/chi-tiet-hoa-don/${item.id}`}>
                                    <tr key={item.id}>
                                        <td>{item.id}</td>
                                        <td>{item.ngay}</td>
                                        <td>{Formater(item.tongTien)}</td>
                                        <td>{item.trangThai}</td>
                                    </tr>
                                </Link>
                            ))}
                        </tbody>
                    </table>

                </div>
            </div>
            <div className="btn">
                <button onClick={() => { window.location.href = ROUTER.USER.HOME }}>Về trang chủ</button>

            </div>
        </div>
        </div>
    );
};

export default memo(OrderUser);
