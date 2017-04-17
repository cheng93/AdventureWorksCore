import React, { Component } from 'react';

import {
  ConnectedRouter,
  routerReducer,
  routerMiddleware,
  push
} from 'react-router-redux'

import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunkMiddleware from 'redux-thunk';

import { createBrowserHistory } from 'history';

import { appReducers } from './app.reducers';
import { AppRouter } from './app.router';

export function App() {
  let history = createBrowserHistory({
    basename: '/WideWorldImporters/'
  });

  let store = createStore(
    appReducers,
    applyMiddleware(
      thunkMiddleware,
      routerMiddleware(history)
    ));

  return (
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <AppRouter />
      </ConnectedRouter>
    </Provider>
  );
}