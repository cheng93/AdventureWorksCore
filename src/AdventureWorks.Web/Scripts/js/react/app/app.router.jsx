import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

import { OrdersRouter } from '../orders/orders.router';

const Home = () => (
  <div>
    <h2>Home</h2>
  </div>
)

const About = () => (
  <div>
    <h2>About</h2>
  </div>
)


export class AppRouter extends Component {
  render() {
    return (
      <Router basename='/WideWorldImporters/'>
        <div>
          <Route exact path="/" component={Home} />
          <Route path="/orders" component={OrdersRouter} />
        </div>
      </Router>
    );
  }
}