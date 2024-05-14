

import { memo, useState, useEffect } from 'react';
import './style.scss';
import { DecodeToken } from '../../../Utils/DecodeToken';
import axios from 'axios';
import { APIGATEWAY, ROUTER } from '../../../Utils/Router';
import { Formater } from '../../../Utils/formater';
import NotFound404 from '../../NotFound404';
import { Form } from 'react-router-dom';

const CartUser = () => {
    const [paymentMethod, setPaymentMethod] = useState("");
    const token = localStorage.getItem('token');
    const [listCart, setListCart] = useState([]);
    let cartData = JSON.parse(localStorage.getItem('cartData'));
    let totalPrice = 0;

    let decodedToken = null;
    if (token !== null && token !== undefined && token !== "" && token !== "null") {
        decodedToken = DecodeToken(token);
    }
    console.log("totalPrice ", totalPrice);

    useEffect(() => {
        if (token !== null && token !== undefined && token !== "" && token !== "null" && decodedToken !== null) {
            const username = decodedToken.username;
            axios.get(APIGATEWAY.CART.BYUSERNAME + username, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                }
            })
                .then(response => {
                    setListCart(response.data);
                })
                .catch(error => { console.log("Lỗi ", error); return <NotFound404 /> });
        } else {

            if (cartData !== null && cartData.length !== 0) {
                setListCart(cartData);
            }
            if (cartData === null || cartData.length !== 0) {
                return <NotFound404 />
            }
        }

        const lblpriceElement = document.getElementById('lblTotalPrice');
        console.log('UpdatePrice ', lblpriceElement);
        if (lblpriceElement !== null) {
            lblpriceElement.textContent = Formater(totalPrice);
        }
    }, [token]);

    const Sub = (item) => {
        const lblElement = document.getElementById(`lbl-num${item.productId}`);
        const priceElement = document.getElementById(`totalPrice${item.productId}`);
        const lblpriceElement = document.querySelectorAll('.lblTotalPrice');

        let num = item.soLuong;
        let price = parseFloat(item.gia / item.soLuong);
        //totalPrice = parseFloat(lblpriceElement.innerText);
        caculatorTotalPrice();
        console.log(lblpriceElement);
        console.log(totalPrice);


        if (num > 1) {
            num--;
            totalPrice -= price;
            price = parseFloat(price * num);

            lblElement.value = num;
            priceElement.textContent = Formater(price);
            lblpriceElement.forEach(lblpriceElement => {
                lblpriceElement.textContent = "Tổng tiền : " + Formater(totalPrice);
            });

            item.soLuong = num;
            item.gia = price;


            updateDataCart(item);
        }

    }

    const Add = (item) => {
        const lblElement = document.getElementById(`lbl-num${item.productId}`);
        const priceElement = document.getElementById(`totalPrice${item.productId}`);
        const lblpriceElement = document.querySelectorAll('.lblTotalPrice');

        let num = item.soLuong;
        let price = parseFloat(item.gia / item.soLuong);
        caculatorTotalPrice();

        if (num < 100) {
            num++;
            totalPrice += price;
            price = parseFloat(price * num);

            lblElement.value = num;
            priceElement.textContent = Formater(price);
            lblpriceElement.forEach(lblpriceElement => {
                lblpriceElement.textContent = "Tổng tiền : " + Formater(totalPrice);
            });

            item.soluong = num;
            item.gia = price;


            updateDataCart(item);
        }


    };

    const updateDataCart = (item) => {
        const index = cartData.findIndex(dataItem => dataItem.productId === item.productId);
        if (index !== -1) {
            cartData[index].soLuong = item.soLuong;
            cartData[index].gia = item.gia;

            localStorage.setItem('cartData', JSON.stringify(cartData));
        }
    }

    const Remove = (productId) => {
        if (cartData !== null) {
            cartData = cartData.filter(item => item.productId !== productId);

            localStorage.setItem('cartData', JSON.stringify(cartData));
            window.alert("Xóa thành công");
            window.location.reload();
        } else {
            return <NotFound404 />;
        }
    }



    console.log(listCart);
    if (listCart === null || listCart.length === 0) {
        return <NotFound404 />
    }
    const caculatorTotalPrice = () => {
        totalPrice = 0;
        if (listCart.length !== 0) {
            listCart.forEach(item => {
                totalPrice += item.gia
            })
        }
    }

    const showFormPay = () => {
        const formorder = document.getElementById("form-order");
        const overlay = document.getElementById("overlay");
        if (formorder.style.display !== "block") {
            overlay.style.display = "block";
            formorder.style.display = "block";
        }
    }
    const handlePaymentMethod = (event) => {
        setPaymentMethod(event.target.value);
    }

    const thanhToan = () => {
        return;
    }
    return (
        <div className="cartpage">

            <div className="container">
                <div className="content">
                    <div className="row">
                        <div className="cartpage col-12">
                            <div className="top">
                                {
                                    listCart.map((item) => (
                                        <div className="item" key={item.productId}>
                                            <img src={item.url} alt={item.ten} />
                                            <span>{item.ten}</span>
                                            <span>{Formater(parseFloat(item.gia / item.soLuong))} / 1 đvt</span>
                                            <div className="btn">
                                                <button className="btn-sub" onClick={() => Sub(item)}>-</button>
                                                <input id={`lbl-num${item.productId}`} defaultValue={item.soLuong} readOnly />
                                                <button className="btn-add" onClick={() => Add(item)}>+</button>
                                            </div>
                                            <span id={`totalPrice${item.productId}`}>{Formater(item.gia)}</span>

                                            <button className="btn-remove" onClick={() => Remove(item.productId)}>Xóa</button>
                                        </div>
                                    ))
                                }
                            </div>
                            <div className="bottom">
                                {caculatorTotalPrice()}
                                <span className="lblTotalPrice">Tổng tiền : {Formater(totalPrice)}</span>

                                <div className="btn">
                                    <button onClick={() => window.location.href = ROUTER.USER.PRODUCT}>Tiếp tục mua sắm</button>
                                    <button onClick={(event) => {
                                        event.preventDefault();
                                        showFormPay();
                                    }
                                    }>Thanh toán</button>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div id="overlay"></div>
                    <div className="form-order" id="form-order">
                        <form>
                            <div className="cancel">
                                <button onClick={(event) => {
                                    event.preventDefault();
                                    const formorder = document.getElementById("form-order");
                                    const overlay = document.getElementById("overlay");
                                    overlay.style.display = "none";
                                    formorder.style.display = "none";
                                }}>x</button>
                            </div>
                            <h1>Thanh toán đơn hàng</h1>
                            <h2>Thông tin thanh toán</h2>
                            <div className="hoten">
                                <div>
                                    <label for="ten">Tên *</label>
                                    <input type="text" id="ten" placeholder="Nhập tên" />
                                </div>
                                <div>
                                    <label for="ho">Họ *</label>
                                    <input type="text" id="ho" placeholder="Nhập họ" />
                                </div>
                            </div>

                            <label for="diachi">Địa chỉ *</label>
                            <input type="text" id="diachi" placeholder="Nhập địa chỉ" />
                            <label for="diachi">Số điên thoại *</label>
                            <input type="tel" id="sdt" placeholder="Nhập số điên thoại" />
                            <select id="paymentMethod" value={paymentMethod} onChange={(event) => handlePaymentMethod(event)}>
                                <option value="">Chọn phương thức thanh toán</option>
                                <option value="Chuyển khoản">Chuyển khoản</option>
                                <option value="Thanh toán khi nhận hàng">Thanh toán khi nhận hàng</option>
                            </select>

                            <span className="lblTotalPrice">Tổng tiền : {Formater(totalPrice)}</span>
                            <button className="btn" onClick={(event) => {
                                event.defaultPrevented();
                                thanhToan();
                            }}>Đặt hàng ngay</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>

    )
};

export default memo(CartUser);