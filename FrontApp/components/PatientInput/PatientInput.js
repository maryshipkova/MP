// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';

type Props = {};

type State = {
    patient: PatientModel
};

export class PatientInput extends React.Component<Props, State> {

    constructor(props) {
        super(props);
        this.state = {
            patient: {
                firstName: "",
                lastName: "",
                sexType: "None",
                birthDate: ""
            }
        };
        this.addPatient.bind(this);
    }


    addPatient(event) {
        this.firstName = this.firstName.value;
        this.lastName = this.lastName.value;
        this.sexType = this.sexType[this.sexType.selectedIndex].value;
        this.birthDate = this.birthDate.value;

        const requestOptions = {
            headers: new Headers({'content-type': 'application/json'}),
            method: "POST",
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify({
                FirstName: this.firstName,
                LastName: this.lastName,
                SexType: this.sexType,
                BirthDate: this.birthDate
            })
        };
        fetch("https://api.4buttons.ru/v0.1/patients", requestOptions);

        event.preventDefault();
    }

    render() {
        return (
            <form className="patient" onSubmit={e => this.addPatient(e)}>
                <input ref={input => this.firstName = input}/>
                <input ref={input => this.lastName = input}/>
                <select ref={selected => this.sexType = selected} defaultValue="0">
                    <option value="1">Male</option>
                    <option value="2">Female</option>
                    <option value="0">Not specified</option>
                </select>
                <input type="date" ref={date => this.birthDate = date}/>
                <button type="submit">Send form</button>
            </form>
        )
    }
};