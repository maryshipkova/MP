// @flow

import React from "react";
import {serverDomain} from "constants/server";

export class PatientTimeLineItem extends React.Component {

    constructor(props) {
        super(props);
        this.state = props;
        this.save = this.save.bind(this);
    }

    save() {
        const requestOptions = {
            headers: new Headers({'content-type': 'application/json'}),
            method: "POST",
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify({
                parameters: {
                    pef: this.pef.value,
                    spO2: this.spO2.value,
                    isHospitalized: this.isHospitalized.checked,
                    isWheezing: this.isWheezing.checked
                }
            })
        };
        fetch(`${serverDomain}/patients/${this.state.patientid}/status`, requestOptions).then((res) => {
            return res.json();
        }).then(res => {
            console.log(res);
            this.setState(Object.assign({unsaved: false}, res.data.patient.status));
        })
    }

    getFullDate() {
        let date = new Date(this.state.createdDate);
        return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`
    }

    getWordFromBoolean(bool) {
        return bool ? "Да" : "Нет";
    }

    render() {
        return (
            <li className="in-view card" ref={li => this.li = li}>
                {this.state.unsaved ? null : <div>
                    <p>Дата записи: {this.getFullDate()}</p>
                    <p>Описание:</p>
                    {this.state.description}
                    {this.state.medicines.length ? <p>
                        Лекарства:<br/>
                        {this.state.medicines.map(medicine => {
                            return <>
                                {medicine.name}<br/>
                                {medicine.description}<br/>
                            </>
                        })}
                    </p> : null}
                </div>}
                <div>
                    <input type="number"
                           placeholder="Pef"
                           step="0.01"
                           value={this.state.parameters.pef}
                           className="form-control"
                           ref={pef => this.pef = pef}
                    />
                    <input type="number" placeholder="Opf2"
                           step="0.01"
                           value={this.state.parameters.spO2}
                           className="form-control mt-1"
                           ref={spO2 => this.spO2 = spO2}
                    />
                    <br/>
                    <label>Госпитализирован:</label>
                    {this.state.unsaved ?
                        <React.Fragment>
                            <input type="checkbox"
                                   checked={this.state.parameters.isHospitalized}
                                   ref={isHospitalized => this.isHospitalized = isHospitalized}
                            />
                        </React.Fragment> : this.getWordFromBoolean(this.state.parameters.isHospitalized)
                    }
                    <br/>
                    <label>Есть кашель:</label>
                    {this.state.unsaved ?
                        <React.Fragment>
                            <input type="checkbox"
                                   checked={this.state.parameters.isWheezing}
                                   ref={isWheezing => this.isWheezing = isWheezing}
                            /><br/>
                        </React.Fragment> : this.getWordFromBoolean(this.state.parameters.isWheezing)}
                    {this.state.unsaved && <button onClick={this.save} className="btn btn-primary">Сохранить</button>}
                </div>
            </li>
        );
    }
}
