module Parse

open FSharp.Text.Lexing
open System
open AST

exception ParseError of Position * string * Exception

let parse parser src =
    let lexbuf = LexBuffer<char>.FromString src

    let parser = parser Lexer.tokenize

    try
        Ok(parser lexbuf)
    with
    | e ->
        let pos = lexbuf.EndPos
        let line = pos.Line
        let column = pos.Column
        let message = e.Message
        let lastToken = new String(lexbuf.Lexeme)
        eprintf "Parse failed at line %d, column %d:\n" line column
        eprintf "Last token: %s" lastToken
        eprintf "\n"
        Error(ParseError(pos, lastToken, e))

// TODO: start here
let rec prettyPrint ast =
   failwith "GCL parser not yet implemented"
   "hello world!"

let analysis (src: string) : string =
    // TODO: start here
    match parse Parser.start (src) with
        | Ok ast ->
            Console.Error.WriteLine("> {0}", ast)
            prettyPrint ast
        | Error e -> "Parse error: {0}"
