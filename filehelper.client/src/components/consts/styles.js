import styled from 'styled-components';

export const FormContainer = styled.form`
    display: flex;
    flex-direction: column;
    margin-top: 40px;
    margin-bottom: 40px;
`;

export const Input = styled.input`
    outline: none;
    padding: 7px;
    border: none;
    font-size: 14px;
    border-bottom: 1px solid #000000;
    margin-bottom: 10px;
`;

export const Button = styled.button`
    height: 30px;
    width: 70px;
    margin-left: auto;
    margin-right: 0;
    color: #ffffff;
    background: #333333;
    border-radius: 2px;
    border: none;
    font-size: 14px;
    font-weight: bold;
    cursor: pointer;
    user-select: none;
    
    &:hover {
        background: #444444;
    }    
`;