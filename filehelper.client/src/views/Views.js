import React, {Component} from 'react';
import styled from 'styled-components';
import FileCounter from "../components/FileCounter";
import FileSorter from "../components/FileSorter";

const Container = styled.div`
    align-items: center;
    display: flex;
    flex-direction: column;
    animation: 'slideIn' 0.3s ease-in-out;
    transition: all 0.3s ease-in-out;
   
    @keyframes slideIn {
        0% {
            transform: translateX(-20vw);
        }
    }
`;

const Title = styled.h1`
    color: #444444;
    font-size: 36px;
    user-select: none;
    cursor: default;
    
    @media screen and (max-width: 700px) {
        font-size: 20px;
    }
`;

const Subtitle = styled.h1`
    width: 80vw;
    color: #444444;
    font-size: 16px;
    text-align: center;
    user-select: none;
    cursor: default;
    
    @media screen and (max-width: 700px) {
        font-size: 12px;
    }
`;

class Views extends Component {
    state = {};

    componentDidMount() {
    };

    render() {
        return (
            <Container>
                <Title>Task 1</Title>
                <Subtitle>Select a folder down below and our magical file helper will calculate the no. of XML files in
                    the directory tree.</Subtitle>
                <FileCounter/>
                <Title>Task 2</Title>
                <Subtitle>Manually sorting your XML files by order date is tedious work. Why not let us do it for you? Simply select CustomerOrders.xml and file helper will automate the task!</Subtitle>
                <FileSorter/>
            </Container>
        );
    };
}

export default Views;