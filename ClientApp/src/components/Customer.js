import React, { Component } from "react";

export class Customer extends Component{
    static displayName = Customer.name;

    constructor(props) {
        super(props);
        this.state = { customers: [], loading: true}
    }

    componentDidMount(){
        this.populateCustomers();
    }

    static renderCustomersTable(customers){
        return(
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Telephone</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map(customer =>
                        <tr key={customer.customerid}>
                            <td>{customer.customerid}</td>
                            <td>{customer.name}</td>
                            <td>{customer.address}</td>
                            <td>{customer.telephoneNumber}</td>
                            <td>{customer.email}</td>
                        </tr>
                        )}                   
                </tbody>
            </table>
        )
    }

    render(){
        let content = this.state.loading
            ? <p><em>Loading....</em></p>
            : Customer.renderCustomersTable(this.state.customers);

        return(
            <div>
                <h1 id="customerTable">Customers </h1>
                <p>This is the list of all customers registered on our system.</p>
                {content}
            </div>
        )
    }

    async populateCustomers(){
        const response = await fetch('https://localhost:7027/api/Customers')
        const data = await response.json();
        this.setState({ customers: data, loading: false});
    }
}