import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';

import { App } from './app.component';
import { OrdersRouter } from '../orders/orders.router';

export function AppRouter() {
  return (
    <Router basename='/WideWorldImporters/'>
      <div>
        <Route exact path="/" component={App} />
        <Route path="/orders" component={OrdersRouter} />
      </div>
    </Router>
  );
}