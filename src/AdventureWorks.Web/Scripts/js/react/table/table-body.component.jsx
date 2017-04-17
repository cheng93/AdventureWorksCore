import React, { Component } from 'react';

function TableBodyRow(props) {
  return (
    <tr>
      <td>{props.row.orderId}</td>
      <td>{props.row.customerId}</td>
      <td>{props.row.orderDate}</td>
    </tr>
  )
}

export class TableBody extends Component {
  render() {
    const tableRows = this.props.rows
      .map(row =>
        <TableBodyRow key={row.orderId} row={row} />
      );

    return (
      <tbody>
        {tableRows}
      </tbody>
    );
  }
}