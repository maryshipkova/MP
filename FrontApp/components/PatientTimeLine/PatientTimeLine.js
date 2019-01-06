// @flow

import React from "react";
import "./style.css";


export class PatientTimeLine extends React.Component {
    constructor() {
        super();

    }

    componentDidMount() {
        let items = this.list.childNodes;

        function isElementInViewport(el) {
            let rect = el.getBoundingClientRect();
            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                rect.right <= (window.innerWidth || document.documentElement.clientWidth)
            );
        }

        function showListItem() {
            for (let i = 0; i < items.length; i++) {
                if (isElementInViewport(items[i])) {
                    items[i].classList.add("in-view");
                }
            }
        }

        window.addEventListener("load", showListItem);
        window.addEventListener("resize", showListItem);
        window.addEventListener("scroll", showListItem);
    }


    render() {
        return (
            <section className="timeline">
                <ul ref={(ul) => this.list = ul}>
                    <li>
                        <div>
                            <time>1934</time>
                            At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium At
                            vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium
                        </div>
                        <div>
                            <time>193444444</time>
                            At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium At
                            vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium
                        </div>

                    </li>
                    <li>
                        <div>
                            <time>1937</time>
                            Proin quam velit, efficitur vel neque vitae, rhoncus commodo mi. Suspendisse finibus mauris
                            et bibendum molestie. Aenean ex augue, varius et pulvinar in, pretium non nisi.
                        </div>
                        <div>
                            <time>19377777</time>
                            Proin quam velit, efficitur vel neque vitae, rhoncus commodo mi. Suspendisse finibus mauris
                            et bibendum molestie. Aenean ex augue, varius et pulvinar in, pretium non nisi.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1940</time>
                            Proin iaculis, nibh eget efficitur varius, libero tellus porta dolor, at pulvinar tortor ex
                            eget ligula. Integer eu dapibus arcu, sit amet sollicitudin eros.
                        </div>
                        <div>
                            <time>1940000000</time>
                            Proin iaculis, nibh eget efficitur varius, libero tellus porta dolor, at pulvinar tortor ex
                            eget ligula. Integer eu dapibus arcu, sit amet sollicitudin eros.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1943</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>194333333333</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1946</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>194666666666666</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1956</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>1956666666666666666</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1957</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>19577777777777</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1967</time>
                            Aenean condimentum odio a bibendum rhoncus. Ut mauris felis, volutpat eget porta faucibus,
                            euismod quis ante.
                        </div>
                        <div>
                            <time>196777777777</time>
                            Aenean condimentum odio a bibendum rhoncus. Ut mauris felis, volutpat eget porta faucibus,
                            euismod quis ante.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1977</time>
                            Vestibulum porttitor lorem sed pharetra dignissim. Nulla maximus, dui a tristique iaculis,
                            quam dolor convallis enim, non dignissim ligula ipsum a turpis.
                        </div>
                        <div>
                            <time>197777777777777</time>
                            Vestibulum porttitor lorem sed pharetra dignissim. Nulla maximus, dui a tristique iaculis,
                            quam dolor convallis enim, non dignissim ligula ipsum a turpis.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>1985</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>198555555555555</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>2000</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>20000000000</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                    <li>
                        <div>
                            <time>2005</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                        <div>
                            <time>20055555555</time>
                            In mattis elit vitae odio posuere, nec maximus massa varius. Suspendisse varius volutpat
                            mattis. Vestibulum id magna est.
                        </div>
                    </li>
                </ul>
            </section>
        );
    }
}
