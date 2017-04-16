import React, { Component } from 'react';
import { Table } from '../../table/table.component';

const columns = [
  { key: 'id', name: 'ID' },
  { key: 'title', name: 'Title' },
  { key: 'count', name: 'Count' }
];

function getRows() {
  let rows = [];
  for (let i = 1; i < 1000; i++) {
    rows.push({
      id: i,
      title: 'Title ' + i,
      count: i * 1000
    });
  }

  return rows;
}

export class Orders extends Component {
  constructor(props) {
    super(props);
    this.state = {
      _columns: columns,
      _rows: getRows()
    };
  }
  
  render() {
    return (
      <div>
        <h2>Orders</h2>
        <Table columns={this.state._columns}
          rows={this.state._rows} />
      </div>
    );
  }
}