import React, { Component } from 'react';
import { Provider } from 'react-redux';

import { AppRouter } from './app.router';

export function App({store}) {
    return (
      <Provider store={store}>
        <AppRouter />
      </Provider>
    );
}