// @flow

import React from "react";
import {serverDomain} from "constants/server";

export class PatientTimeLineItem extends React.Component {

    constructor(props) {
        super(props);
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
        fetch(`${serverDomain}/patients/${this.props.patientid}/status`, requestOptions).then((res) => {
            return res.json();
        }).then(res => {
            console.log(res);
        })
    }

    getFullDate() {
        let date = new Date(this.props.createdDate);
        return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`
    }

    render() {
        return (
            <li className="in-view" ref={li => this.li = li}>
                <div>
                    <p>Дата записи: {this.getFullDate()}</p>
                    <p>Описание:</p>
                    {this.props.description}
                    {this.props.medicines.length ? <p>
                        Лекарства:<br/>
                        {this.props.medicines.map(medicine => {
                            return <>
                                {medicine.name}<br/>
                                {medicine.description}<br/>
                            </>
                        })}
                    </p> : null}
                </div>
                <div>
                    <input type="number"
                           placeholder="Pef"
                           step="0.01"
                           value={this.props.parameters.pef}
                           ref={pef => this.pef = pef}
                    />
                    <input type="number" placeholder="Opf2"
                           step="0.01"
                           value={this.props.parameters.spO2}
                           ref={spO2 => this.spO2 = spO2}
                    />
                    <br/>
                    <label>Hospitalized</label>
                    <input type="checkbox"
                           checked={this.props.parameters.isHospitalized}
                           ref={isHospitalized => this.isHospitalized = isHospitalized}
                    />
                    <br/>
                    <label>Wheezing</label>
                    <input type="checkbox"
                           checked={this.props.parameters.isWheezing}
                           ref={isWheezing => this.isWheezing = isWheezing}
                    /><br/>
                    <button onClick={this.save}>Сохранить</button>
                </div>
            </li>
        );
    }
}
