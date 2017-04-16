import React, { Component } from 'react';

import { TableHead } from './table-head.component';
import { TableBody } from './table-body.component';

export class Table extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <table className="table table-striped">
        <TableHead columns={this.props.columns} />
        <TableBody rows={this.props.rows} />
      </table>
    );
  }
}