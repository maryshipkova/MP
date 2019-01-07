// @flow

import {PatientModel} from './PatientModel'

export class PatientListModel{
    constructor(patients: PatientModel){
        this.patients = patients;
    }

    patients: PatientModel[];
}