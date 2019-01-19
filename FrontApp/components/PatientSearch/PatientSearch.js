import React from "react";

import "./style.css";

export class PatientSearch extends React.Component{

    constructor(props){
        super(props);
        this.onTextChanged = this.onTextChanged.bind(this);
    }

    onTextChanged(e){
        let text = e.target.value.trim();
        this.props.filter(text);
    }

    render() {
        return <input className="patient-search" placeholder="Введите имя" onChange={this.onTextChanged} />;
    }
}
