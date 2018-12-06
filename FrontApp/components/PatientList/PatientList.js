// @flow

import React from 'react';
import {Patient} from 'components/Patient';
import {PatientModel} from 'models/PatientModel';
import {PatientListModel} from 'models/PatientListModel';

type Props = {};

type State = {
    patients: PatientListModel,
};

export class PatientList extends React.Component<Props, State> {

    constructor() {
        super();

        let {patients} = new PatientListModel(
            [
                new PatientModel(
                    1,
                    "Ivan",
                    "Ivanov",
                    "Ivanovich",
                    18,
                    "Male",
                    "sun.jpg"
                )
            ]
        );

        this.state = {
            patients
        }
    }

    componentDidMount() {
        /*Send request to get patients*/
    }

    sort() {

    }

    render() {
        return (
            this.state.patients.length > 0 &&
            this.state.patients.map((patient: PatientModel) => {
                return <Patient key={patient.id} {...patient}/>
            })
        )
    }
};
