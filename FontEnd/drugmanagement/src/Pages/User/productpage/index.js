import { memo } from 'react';
import React, { useState, useEffect } from 'react';
import { Link, useParams, useHistory, useLocation, Await } from 'react-router-dom';
import { APIGATEWAY, ROUTER } from '../../../Utils/Router';
import { MdOutlineKeyboardArrowRight } from "react-icons/md";
import { Formater } from '../../../Utils/formater';
import axios from 'axios';
import './style.scss';
import NotFound404 from '../../NotFound404';
import { wait } from '@testing-library/user-event/dist/utils';

const ProductUser = () => {
    const { categoryId } = useParams();
    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const searchString = searchParams.get('search');
    const [products, setProducts] = useState([]);
    const [filteredProducts, setFilteredProducts] = useState([]);
    console.log('category ' + categoryId);
    console.log("tìm kiếm " + searchString);

    useEffect(() => {
        fetchProducts(categoryId, searchString);
    }, [categoryId, searchString]);

    const fetchProducts = (categoryId, searchString) => {
        let apiUrl = "https://localhost:8001/api/Product";

        if (categoryId !== undefined) {
            apiUrl = APIGATEWAY.PRODUCT.BYCATEGORYID + categoryId;
        }

        console.log('url ' + apiUrl);

        axios.get(apiUrl)
            .then(response => {
                setProducts(response.data);
                filterProducts(searchString, response.data);
            })
            .catch(error => { console.error('Error fetching products:', error); return <NotFound404 />; });
    };

    const filterProducts = (searchString, products) => {
        if (searchString !== null && searchString !== "") {
            const filter = products.filter(item =>
                item.ten.toLowerCase().includes(searchString.toLowerCase())
            );
            setFilteredProducts(filter);
            console.log(filter);
        } else {
            setFilteredProducts(products);
        }
    };


    if (products.length !== 0) {
        if (searchString !== null || searchString !== "") {
            if (filteredProducts.length === 0) {
                return <NotFound404 />;
            }
        }
        if (categoryId !== undefined) {
            if (filteredProducts.length === 0) {
                return <NotFound404 />;
            }
        }
    }

    return (
        <>
            <div className="product">
                <div className="container">
                    <div className="row">
                        <div className="col-12">
                            <div className="tag">
                                <span className="active">Sản phẩm</span>
                                <MdOutlineKeyboardArrowRight className="active" />
                                <span className={categoryId !== undefined ? "active" : ""}>Danh mục : {categoryId}</span>
                                <MdOutlineKeyboardArrowRight className={categoryId !== undefined ? "active" : ""} />
                                <span className={searchString !== null ? "active" : ""}>Tên : {searchString}</span>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-12">
                            <div className="list-item">
                                {
                                    filteredProducts.map((item) => (
                                        <div key={item.id} className="item" >
                                            <Link to={`/chi-tiet-san-pham/${item.id}`}>
                                                <div className="img">
                                                    <img src={item.url} alt={item.name} />
                                                </div>
                                                <div className="name">
                                                    <span>{item.ten}</span>
                                                </div>
                                                <p>{Formater(item.gia)}</p>
                                            </Link>
                                        </div>
                                    ))
                                }
                            </div>
                        </div>

                    </div>
                        
                </div>
            </div>
        </>
    );
}
export default memo(ProductUser);