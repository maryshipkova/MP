// @flow

import React from 'react';
import './style.css';
import {PatientModel} from 'models/PatientModel';
import {sexType} from 'types/SexType';
import {serverDomain} from "constants/server";

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
                genderType: 0,
                birthDate: ""
            }
        };
        this.addPatient.bind(this);
    }


    addPatient(event) {
        this.firstName = this.firstName.value;
        this.lastName = this.lastName.value;
        this.genderType = this.genderType[this.genderType.selectedIndex].value;
        this.birthDate = this.birthDate.value;

        const requestOptions = {
            headers: new Headers({'content-type': 'application/json'}),
            method: "POST",
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify({
                FirstName: this.firstName,
                LastName: this.lastName,
                GenderType: this.genderType,
                BirthDate: this.birthDate
            })
        };
        fetch(`${serverDomain}/patients`, requestOptions);

        event.preventDefault();
    }

    render() {
        return (
            <form className="patient" onSubmit={e => this.addPatient(e)}>
                <input ref={input => this.firstName = input} placeholder="First Name"/>
                <input ref={input => this.lastName = input} placeholder="Last Name"/>
                <select ref={selected => this.genderType = selected} defaultValue="0">
                    <option value="1">Male</option>
                    <option value="2">Female</option>
                    <option value="0">Not specified</option>
                </select>
                <input type="date" ref={date => this.birthDate = date}/>
                <button type="submit" className="btn btn-primary">Add new Patient</button>
            </form>
        )
    }
};